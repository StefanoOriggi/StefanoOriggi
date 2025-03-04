const express = require('express');
const app = express();
app.set('view engine', 'ejs');

app.get('/users/:username', (req, res) => { 
    const username = req.params.username;
    const temp = { username: username };
    res.render('index', {data: temp});
});

app.all('/', (req, res) => {
    res.send('Errore');
});
app.listen(3000);