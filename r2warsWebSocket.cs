﻿using WebSocketSharp;
using WebSocketSharp.Server;
namespace r2warsTorneo
{
    public class r2warsWebSocket : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string recv = e.Data;
            string msg = "";
            if (recv == "refresh")
            {
                msg = r2warsStatic.r2w.json_output();
            }
            else if (recv == "next")
            {
                r2warsStatic.r2w.btStep_Click();
                msg = r2warsStatic.r2w.json_output();
            }
            else if (recv == "reset")
            {
                //r2warsStatic.r2w.btInit_Click();
                r2warsStatic.ini.btLoadPlayer();
                r2warsStatic.r2w.initmemoria();
                msg = r2warsStatic.r2w.json_output();
            }
            else if (recv == "start")
            {
                //r2warsStatic.r2w.btAuto_Click();
  
                r2warsStatic.ini.btRunCombats();
                msg = r2warsStatic.r2w.json_output();
            }
            else if (recv == "stop")
            {
                r2warsStatic.r2w.stopProcess = true;
                msg = r2warsStatic.r2w.json_output();
            }
            else if(recv=="moreflow")
            {
                r2warsStatic.r2w.sync_var = true;
                msg = "none";
                
            }
            if (msg!="")
                Send(msg);
        }

        private void R2wars_EventPinta(object sender, MyEvent e)
        {
            r2warsStatic.r2w.sync_var = false;
            Send(e.message);
        }
   
        protected override void OnOpen()
        {
            r2warsStatic.r2w.Event_pinta += R2wars_EventPinta;
            base.OnOpen();
        }
    }
}