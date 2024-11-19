function Inserimento() {
    let input = document.getElementById("input").value;
    let array = input.split(",");
    console.log(array);
    let dispari = [];
    for (let i = 0; i < array.length; i++) {
        if (array[i].length % 2 != 0) {
            dispari[i] = array[i];
        }
    }
    document.getElementById("output").innerHTML = dispari;
}