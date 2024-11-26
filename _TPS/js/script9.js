
// Pop rimuove l'ultimo elemento
// Shift rimuove il primo elemento
let array = ["Apple", "Banana", "Orange", "Mango","Kiwi", "Pineapple"];
//let popped = array.pop();
//let shifted = array.shift();
//Slice rimuove un elemento in base all'indice
//let remElement = array.splice(1, 1);

//funzione che rimouve un elemento specifico scorrendo l'array
function removeElement(array, elementToRemove) {
    array.forEach((item, index) => {
        if (item === elementToRemove) {
            array.splice(index, 1);
        }
    });
    return array;
}
// Remove Specific Item from Array
removeElement(array, "Banana");

