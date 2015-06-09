using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        public string name;
        //private UserClient user = new UserClient("BasicHttpBinding_IUser", "http://wcf.edument.se/User.svc");
        
        public void Connect(string nickName)
        {
           
            name = nickName;
            try
            {
                //user.Connect(name);
            }
            catch (FaultException<string> i)
            {
                throw new FaultException<string>(i.Message);
            }
        }

        public void Disconnect(string nickName)
        {
             
             try
            {
               // user.Disconnect(name);
                
            }catch(FaultException<string> i){
               throw new FaultException<string>( i.Message);
            }
        }
        public string NickName()
        {
            return name;
        }


        public string UserName()
        {
            throw new NotImplementedException();
        }
    }
}
