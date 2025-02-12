var express = require('express');
var fs = require('fs');
const app = express();

app.get('/', (req, res) => {
    fs.readFile('values.txt', 'utf8', (err, data) => {
        if (err) {
            return res.status(500).send('Error reading file');
        }
        const values = data.split('\n')
        res.end("<p> " + values + "</p>");

    });
});

app.get('/values/gt/:val', (req, res) => {
    const val = parseInt(req.params.val);
    fs.readFile('values.txt', 'utf8', (err, data) => {
        if (err) {
            return res.send('Error reading file');
        }
        const values = data.split('\n').map(Number).filter(num => num > val);
        res.json(values);
    });
});

app.get('*', (req, res) => {
    res.send('Hello World');

});
app.listen(3000);