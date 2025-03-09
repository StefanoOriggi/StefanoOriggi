const express = require('express');
const app = express();
const mongo = require('mongodb').MongoClient;
var url = "mongodb://localhost:27017/";

const headHTML = '<!DOCTYPE html><html lang="it"><head><meta charset="UTF-8"><meta name="viewport" content="width=device-width, initial-scale=1.0"><title>Agenda Web</title><link rel="stylesheet" href="/style.css"></head><body><div class="container"><h1>Agenda Web</h1><div class="current-date">'+Date()+'</div><div class="events-grid">'
const footHTML = '</div><a href="/new-event.html"><button class="add-button">+</button></a></div></body></html>'

app.use(express.static('public'));
app.use(express.urlencoded({ extended: true }));

app.get('/eventi/:anno/:mese/:giorno', (req, res) => {
    const eventi = []

    //al posto di leggere dal file leggo dal db
    mongo.connect(url).then(db => {
        dbo = db.db("agenda");
        dbo.collection('eventi').find({}).toArray()
            .then(result => {
                res.json(result);
                db.close();
            });
    });
});

app.post('/eventi/', (req, res) => {
    const titolo = req.body.title;
    const data = req.body.date;
    const descrizione = req.body.description;
    const ora = req.body.time;

    //al posto di append file salvo sul db
    mongo.connect(url).then(db => {
        db.db("agenda").collection('eventi').insertOne(
            { titolo: titolo, data: data, descrizione: descrizione, ora: ora })
            .then(result => {
                res.send("Fatto");
                db.close();
            })
     });
})

app.get('/', (req, res) => {
    const day = new Date().getDate();
    const month = new Date().getMonth() + 1;
    const year = new Date().getFullYear();

    //controllo se gli eventi per il giorno sono presenti nel db
    mongo.connect(url).then(db => {
        dbo = db.db("agenda");
        dbo.collection('eventi').find({}).toArray()
            .then(result => {
                let risposta = headHTML;
                result.forEach(
                    (line) => {
                        const lDay = line.data.split('-')[2];
                        const lMonth = line.data.split('-')[1];
                        const lYear = line.data.split('-')[0];

                        if(lDay == day && lMonth == month && lYear == year){
                            risposta += '<div class="event-card"><div class="event-time">'+line.ora+'</div><div class="event-title">'+line.titolo+'</div><div class="event-description">'+line.descrizione+'</div></div>'
                        }
                    }
                );
                risposta += footHTML;
                res.send(risposta);
                db.close();
            });
     });
});

app.listen(3000);