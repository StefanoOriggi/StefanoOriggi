function Binario() {
    let input = document.getElementById("input").value;
    if (input == null || input <= 0) {
        alert("Inserisci un numero INTERO E POSITIVO");
        return;
    }
    let binario = "";
    while (input > 0) {
        binario = input % 2 + binario;
        input = input >>> 1;
    }
    document.getElementById("output").innerHTML = binario;
}