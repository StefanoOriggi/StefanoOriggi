function Inserimento() {
    let input = document.getElementById("input").value;
    let array = input.split(",");
    let dispari = array.filter(x => !null && x % 2 != 0);
    let output = dispari.join(",");
    document.getElementById("output").innerHTML = output;
}