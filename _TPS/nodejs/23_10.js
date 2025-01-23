/* Esempi function di call-back

function processUserData(data, callback) {
  console.log("processing user data:", data);
  callback();
}

function fetchUserDatawithCallback(callback) {
  const userData = { id: 1, name: "nome1" };
  callback(userData);
}

fetchUserDatawithCallback((data) => {
  processUserData(data, () => {
   console.log("User data processed successfully.")
  }); 
});

*/


/*
var fs = require('fs')
function fetchUserDatawithCallback(callback) {
  fs.readFile("file.txt", 'utf8', (_err, data) => {
    callback(data);
  });
}

fetchUserDatawithCallback(userData => {
    console.log("il contenuto del file è: ", userData);
});
console.log("Dopo")
*/


function fetchUserDatawithPromise() {
  const userData = { id: 1, name: "nome1" };
  return new Promise((resolve, reject) => {
    if (userData) {
      resolve(userData)
    } else {
      reject("Error fetching user data.");
    }
  });
}
fetchUserDatawithPromise().then((data) => {
  console.log("Processing user data:", data);
  console.log("User data processed successfully");
}).catch((error) => {
  console.error("Error:", error)
});