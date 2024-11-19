function InserimentoNumeri() {
    let input = document.getElementById("input").value;
    let list = document.getElementById("lista");
    let create = document.createElement("li");
    create.appendChild(document.createTextNode(input));
    list.appendChild(create);

    let numeri = list.getElementsByTagName("li");
    let somma = 0;
    for (let i = 0; i < numeri.length; i++) {
        somma += parseInt(numeri[i].textContent);
    }
    let media = somma / numeri.length;
    document.getElementById("media").textContent = media;
    document.getElementById("input").value = "";
}