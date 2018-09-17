using ServiceContract;
using SqlModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceHost
{
   public class ServiceMethods : IServiceContract
    {
        private static System.ServiceModel.ServiceHost host { set; get; }
        private static DbContext db { set; get; }
        private static DbSet<Accounts> dbSet { set; get; }
        private static Accounts userInfo { set; get; }
        private static string order { set; get; }
        private static Button btn { set; get; }
        public ServiceMethods()
        {
            db = new E5_Entities();
            dbSet = db.Set<Accounts>();
        }
        //开启服务，将按键Text改为"已启动服务"。
        public void start(Button f=null)
        {
            if (host == null)
            {
                #region 代码设置主机
                //BasicHttpBinding wb = new BasicHttpBinding();
                //wb.MaxBufferPoolSize = 4294967296;
                //host = new System.ServiceModel.ServiceHost(typeof(ServiceMethods), new Uri("http://192.168.31.12:8099/AccountsService"));
                //host.AddServiceEndpoint(typeof(IServiceContract), wb, "AccountsService");
                //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                //smb.HttpGetEnabled = true;
                //host.Description.Behaviors.Add(smb);
                #endregion
                #region 配置文件设置主机
                host = new System.ServiceModel.ServiceHost(typeof(ServiceMethods));
                #endregion

            }
            if (f!=null)
            {
                btn = f;
                order = btn.Text;
            }           
            if (host.State != CommunicationState.Opened)
            {
                host.Open();
                f.Text = "已启动服务";
            }
        }
        //更新命令
        public void refresh(string txtOrder)
        {
            
            if (host.State != CommunicationState.Opened)
            {
                btn.Text = "未启动服务";
                return;
            }
            order = txtOrder;
            btn.Text = txtOrder;
        }
        //获得指令
        public string GetOrder()
        {
            if (order!="")
            {
                return order;
            }
            return "没有指令";
        }
        //添加用户信息
        public bool AddUserInfo(Accounts userInfo)
        {
            dbSet.Add(userInfo);
            if (db.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }
        //删除用户信息
        public bool DeleteUserInfo(Accounts userInfo)
        {
            db.Entry<Accounts>(userInfo).State = EntityState.Deleted;
            int de = db.SaveChanges();
            return true;
        }
        //编辑用户信息
        public int EditUserInfo(Accounts userInfo)
        {
            Accounts user_new = dbSet.Where(a => a.ID == userInfo.ID).FirstOrDefault();
            DeepCopy(ref user_new, userInfo);
            db.Entry<Accounts>(user_new).State = EntityState.Modified;
            return db.SaveChanges();           
            #region 上锁
            //bool lockTaken = false;
            //try
            //{
            //    slock.Enter(ref lockTaken);
            //    Accounts user_new = dbSet.Where(a => a.ID == userInfo.ID).FirstOrDefault();
            //    DeepCopy(ref user_new, userInfo);
            //    db.Entry<Accounts>(user_new).State = EntityState.Modified;
            //    return db.SaveChanges();
            //}
            //finally
            //{
            //    if (lockTaken)
            //    {
            //        slock.Exit(false);
            //    }
            //}
            #endregion
        }
        //深复制
        public void DeepCopy(ref Accounts user_new, Accounts userInfo)
        {
            PropertyInfo[] propertyInfos = userInfo.GetType().GetProperties();
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                PropertyInfo properptyinfo = propertyInfos[i];
               var pro_name= properptyinfo.Name;
                if (pro_name != "ID" & pro_name != "loginAppleId" & pro_name != "loginPassword")
                {
                    properptyinfo.SetValue(user_new, properptyinfo.GetValue(userInfo));
                }
                
            }
        }

        public List<Accounts> GetAllUserInfos()
        {
            List<Accounts> allUserInfos = dbSet.Where(a => true).ToList();
            return allUserInfos;
        }

        public Accounts GetAUserInfo(int id=1)
        {
            userInfo=dbSet.Where(a => a.ID == id).FirstOrDefault();
            return userInfo;
        }

        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
        //返回用于登陆的用户信息
        public Accounts Login()
        {
            userInfo = dbSet.Where((u) => u.remarks != "登录成功" & u.remarks != "ID被禁用" & u.remarks != "正在尝试登录" & u.remarks != "未知错误").FirstOrDefault();
            userInfo.remarks = "正在尝试登录";
            db.Entry<Accounts>(userInfo).State = EntityState.Modified;
            db.SaveChanges();
            return userInfo;
        }
        //返回没有地址信息的第一条用户信息
        public Accounts GetNoneAddr()
        {
            userInfo = dbSet.Where((u) => u.shippingUserFistName == null).FirstOrDefault();
            return userInfo;
        }
        //返回用于测试的用户信息
        public Accounts Test()
        {
            Accounts userInfo = dbSet.Where(u => u.remarks == null).FirstOrDefault();
            userInfo.remarks += "py_test|";
            EditUserInfo(userInfo);
            btn.Text = userInfo.ID.ToString();
            return userInfo; 
        }
    }
}
