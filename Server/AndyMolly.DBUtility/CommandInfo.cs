using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AndyMolly.DBUtility
{
   public class CommandInfo
    {
       public object ShareObject = null;
       public object OriginalData = null;
       private event EventHandler _solicitationEvent;
       public event EventHandler SolicitationEvent
       {
           add 
           {
               _solicitationEvent += value;
           }
           remove
           {
               _solicitationEvent -= value;
           }
       }
       public void OnSolicitationEvent()
       {
           if (_solicitationEvent != null)
           {
               _solicitationEvent(this, new EventArgs());
           }
       }

       public string CommandText;
       public System.Data.Common.DbParameter[] Parameters;
       public EffentNextType EffentNextType = EffentNextType.None;

       public CommandInfo()
       {
       }
       public CommandInfo(string sqlText, SqlParameter[] parameter)
       {
           this.CommandText = sqlText;
           this.Parameters = parameter;
       }
       public CommandInfo(string sqlText, SqlParameter[] parameter, EffentNextType type)
       {
           this.CommandText = sqlText;
           this.Parameters = parameter;
           this.EffentNextType = type;
       }
    }
}
