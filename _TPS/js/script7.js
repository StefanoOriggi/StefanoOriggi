var limite = 0;
function Inverti(x) {
    let testo = x.innerText;
    let reversed = " ";
    for (let index = testo.length-1; index >= 0; index--) {
        reversed += testo[index];
    }
    alert(reversed);
}
function Limitato(x) {
    limite++;
    let testo = x.innerText;
    let reversed = " ";
    if (limite<=3) {
        Inverti(x);
    }
    else
        alert("Limite di inversioni raggiunto (max 3); counter inversioni" + limite);
}