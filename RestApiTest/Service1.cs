using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
//using System.Threading.Tasks;

namespace RestApiTest
{
    public class Service1 : IService1
    {
        Sqlservercon sqlservercon = new Sqlservercon();

        public void GetOptions()
        {
            WebOperationContext ctx = WebOperationContext.Current;
            ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            
            if (ctx.IncomingRequest.Method == "OPTIONS")
            {
                ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "POST, PUT, DELETE");

                ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
                ctx.OutgoingResponse.Headers.Add("Access-Control-Max-Age", "1728000");
            }
        }
        public Result PostUserData(UserData user)
        {
            WebOperationContext ctx = WebOperationContext.Current;
            string[] cors = ctx.OutgoingResponse.Headers.GetValues("Access-Control-Allow-Origin");
            if (cors == null || cors.Length == 0)
                ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            if (ctx.IncomingRequest.Method == "OPTIONS")
            {
                ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "POST, PUT, DELETE");

                ctx.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
                ctx.OutgoingResponse.Headers.Add("Access-Control-Max-Age", "1728000");
            }

            Result result = new Result();
            if (GetUserData(user.Name).Code == 400)
            {
                sqlservercon.Adduser(user);
                result.Code = 200;
                result.Stu = user.Name + "Success";
                result.userData = user;
                return result;
            }
            else
            {
                result.Code = 400;
                result.Stu = user.Name + "fail";
                return result;
            }
        }

        public Result DeleteUserData(UserData user)
        {
            Result result = new Result();
            if (GetUserData(user.Name).Code == 400)
            {
                result.Code = 400;
                result.Stu = user.Name + "fail";
                return result;
            }
            else
            {
                sqlservercon.Deleteuser(user);
                result.Code = 200;
                result.Stu = user.Name + "Success！";
                result.userData = user;
                return result;
            }
        }
        static List<Result> results = new List<Result>();
        public Result GetUserData(string name)
        {
            string[] cors = WebOperationContext.Current.OutgoingResponse.Headers.GetValues("Access-Control-Allow-Origin");
            if (cors == null || cors.Length == 0)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

            UserData userData = sqlservercon.Selectuser(name);
            Result result = new Result();
            if (userData.Name != "")
            {
                result.userData = userData;
                result.Code = 200;
                result.Stu = "Success";
                results.Add(result);
                Console.WriteLine(results.Count);
                return result;
            }
            else
            {
                result.Code = 400;
                result.Stu = "fail";
                return result;
            }


        }
        public Result PutUserData(UserData user)
        {
            Result result = new Result();
            if (GetUserData(user.Name).Code == 400)
            {
                result.Code = 400;
                result.Stu = user.Name + "fail";
                return result;
            }
            else
            {
                sqlservercon.Updateuser(user);
                result.Code = 200;
                result.Stu = user.Name + "Success";
                result.userData = user;
                return result;
            }
        }
    }
}
