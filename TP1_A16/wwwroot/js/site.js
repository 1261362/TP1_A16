// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function verifyPassword() {
    const passwordInput = document.getElementById("Password");
    const correctPassword = "gab2024";
    if (passwordInput.value == correctPassword) {
        document.getElementById("lienPage").style.display = "block"; // Afficher le conteneur des liens
    } else {
        alert("Mot de passe incorrect !");
    }

    return false; 
}

