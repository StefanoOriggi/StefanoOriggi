function F1(x) {
    var testo = x.innerText;
    let counter = 0;
    for (let index = 0; index < testo.length; index++) {
        if (testo[index] == "a") {
            counter++;
        }
    }
    if (counter != 0)
        alert("Numero occorrenze a: " + counter);
    else
        alert("Nessuna occorrenza di a");
    
}
function F2(x) {
    car = prompt("Inserisci il carattere scelto:");
    var testo = x.innerText;
    let counter = 0;
    for (let index = 0; index < testo.length; index++) {
        if (testo[index] == car) {
            counter++;
        }
    }
    if (counter != 0)
        alert("Numero occorrenze di  " + car + " "+ counter);
    else
        alert("Nessuna occorrenza di " +car);
}