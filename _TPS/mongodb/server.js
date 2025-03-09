var mongo = require('mongodb').MongoClient
var express = require('express');

var app = express();
let url = 'mongodb://localhost:27017';

app.get('/posts/', (req, res) => {
    mongo.connect(url).then(db => {
        dbo = db.db("blog");
        dbo.collection('posts').find({}).toArray()
            .then(result => {
                res.json(result);
                db.close();
            })
    });
});

app.get('/insert/', (req, res) => {
    mongo.connect(url).then(db => {
        dbo = db.db("blog");
        dbo.collection('posts').insertOne(
            { title: "aggiunto da web app", category: "web app" })
            .then(result => {
                res.send("Fatto");
                db.close();
            })
    });
});
app.listen(3000);
