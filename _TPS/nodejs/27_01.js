var http = require('http');
var url = require('url');
var fs = require('fs')

function getEventsByProvince(province, callback) {
    fs.readFile('eventi_lombardia.csv', 'utf8', function (err, data) {
        if (err) {
            callback(err, null);
            return;
        }
        const events = data.split('\n').filter(line => line.includes(province));
        callback(null, events);
    });
}

http.createServer(function (req, res) {
    const q = url.parse(req.url, true).query;
    const province = q.province;

    if (province) {
        getEventsByProvince(province, function (err, events) {
            if (err) {
                res.writeHead(500, { 'Content-Type': 'text/plain' });
                res.write('Error');
                return res.end();
            }
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.write('<html><body><h1>Eventi in provincia di ' + province + '</h1>');
            events.forEach(event => {
                res.write(event + '<br>');
            });
            res.write('</body></html>');
            return res.end();
        });
    } else {
        fs.readFile('27_01.html', function (err, data) {
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.write(data);
            return res.end();
        });
    }
}).listen(8080);
