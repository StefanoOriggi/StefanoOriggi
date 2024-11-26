let x = [3, 43, 1, 2, 220, 6, 7,];
let new_x = [];
for (let index = 0; index < x.length; index++) {
    if (x[index] % 2 != 0) {
        new_x.push(x[index]);
    }
}
x = new_x //copia di riferimento (x è 'puntatore')
/*
commenti sull'es 4
*/