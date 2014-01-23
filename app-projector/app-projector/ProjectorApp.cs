using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rv;

namespace app_projector
{
    class ProjectorApp
    {
        public enum InputType
        {
            COMPUTER,
            VIDEO,
            //DIGITAL_A,
            DIGITAL_D,
            HDMI,
            S_VIDEO,
            NETWORK
        }

        private int port = 1024;
        private string host = "192.168.10.100";
        private string password = "panasonic";

        private PJLinkConnection link;

        public ProjectorApp()
        {
            link = new PJLinkConnection(host, password);

        }

        public void turnOn()
        {
            link.turnOn();
        }

        public void turnOff()
        {
            link.turnOff();
        }

        public void setInput(InputType input)
        {
            InputCommand.InputType type = InputCommand.InputType.UNKNOWN;
            switch (input)
            {
                case InputType.COMPUTER:
                    type = InputCommand.InputType.RGB;
                    break;
                case InputType.DIGITAL_D:
                    type = InputCommand.InputType.DIGITAL_D;
                    break;
                case InputType.HDMI:
                    type = InputCommand.InputType.HDMI;
                    break;
                case InputType.NETWORK:
                    type = InputCommand.InputType.NETWORK;
                    break;
                case InputType.S_VIDEO:
                    type = InputCommand.InputType.S_VIDEO;
                    break;
                case InputType.VIDEO:
                    type = InputCommand.InputType.VIDEO;
                    break;
            }

            link.sendCommand(new InputCommand(type, 1024));
        }

    }
}
