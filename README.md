# native-print-in-web
Using the windows native printing service in the network. Lets you use the printer installed on the host computer directly from the web
## How to use
1. Install the release version of the application on the host computer.  
2. Run the application.  
3. connect to WebSocket address ws://127.0.0.1:9901.
4. send the following json to the server:  

```json
{
    "printer_name": "Printer name, like 'Microsoft Print To PDF'",
    "page_width": 210,
    "page_height": 297,
    "pdf_base64":"the file(PDF ONLY) you want to print, after BASE64 ENCODE"
}
```
5. The server will return the following json to you:  
```json
{
    "success":0 or 1,
    "msg":""
}
```
6. If success is 1, the printer will print the file you sent.  
1. If success is 0, the msg will tell you what's wrong.  
## Example
![postman.png](doc_img%2Fpostman.png)  
## How to Install
### Build from source
1. Install Visual Studio 2022 and .NET 6.0 SDK
2. Clone this repo
3. Open the solution file in Visual Studio
4. Build the solution
5. Done
### Download from release
Download from [release](https://github.com/cccaimingjian/native-print-in-web/releases)
