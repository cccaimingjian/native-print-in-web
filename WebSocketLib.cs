using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;
using Newtonsoft.Json;

namespace native_print_in_web
{
    internal class WebSocketLib
    {
        private static WebSocketServer? _server;
        private List<IWebSocketConnection> _connectSocketPool = new();
        private PrintLib _printLib = new PrintLib();

        public async void StartSocketListen()
        {
            _server ??= new WebSocketServer("ws://127.0.0.1:9901");

            //开启监听
            _server.Start(socket =>
            {
                //注册客户端连接建立事件
                socket.OnOpen = () =>
                {
                    //将当前客户端连接对象放入连接池中
                    _connectSocketPool.Add(socket);
                };
                //注册客户端连接关闭事件
                socket.OnClose = () =>
                {
                    //将当前客户端连接对象从连接池中移除
                    _connectSocketPool.Remove(socket);
                };
                //注册客户端发送信息事件
                socket.OnMessage = message =>
                {
                    try
                    {
                        //把message转为json对象
                        var req = JsonConvert.DeserializeObject<MessageBody>(message);
                        if (req == null)
                        {
                            return;
                        }

                        var pdf = req.pdf_base64;
                        //解析file_base64，把内容保存到临时目录
                        var pdfBytes = Convert.FromBase64String(pdf);
                        var pdfPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
                        File.WriteAllBytes(pdfPath, pdfBytes);
                        //调用打印机打印这个pdf
                        string printerName = req.printer_name != "" ? req.printer_name : "Microsoft Print To PDF";
                        _printLib.PrintPdfFile(printerName, pdfPath);
                        socket.Send(JsonConvert.SerializeObject(new ResponseBody(1,"")));
                    }
                    catch (Exception e)
                    {
                        // Console.WriteLine(e);
                        // throw;
                        socket.Send(JsonConvert.SerializeObject(new ResponseBody(0,e.Message)));
                    }
                };
            });
        }

        class MessageBody
        {
            public string pdf_base64 { get; set; }
            public string printer_name { get; set; }
            public int page_width { get; set; }
            public int page_height { get; set; }
        }

        class ResponseBody
        {
            public ResponseBody(int success, string msg)
            {
               this.success = success;
               this.msg = msg;
            }

            public int success { get; set; }

            public string msg { get; set; }
        }
    }
}
