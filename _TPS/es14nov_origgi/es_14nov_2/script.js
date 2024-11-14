function Inserimento() {
    let input = document.getElementById("input").value;
    let array = input.split(",").map(stringa => stringa.trim());
    let dispari = array.filter(stringa => stringa.length % 2 != 0)
    let output = dispari.join(",");
    document.getElementById("output").innerHTML = output;
}