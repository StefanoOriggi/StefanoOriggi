var http = require('http');
var fs = require('fs');


http.createServer(function (req, res) {
  res.writeHead(200, { 'Content-Type': 'text/text' });
  res.end('Hello World!');
  var _url = req.url

  fs.appendFile("response.txt", _url + "\n", function(err) {
    if (err) throw err;
  });
}).listen(8080);  
