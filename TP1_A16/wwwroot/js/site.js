// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function verifierPassword() {
    const passwordInput = document.getElementById("Password");
    const nameInput = document.getElementById("Name")
    const correctPassword = "gab2024";

    if (passwordInput.value === correctPassword) {
        window.location.href = '/html/modifierDonner.html'; // Redirection vers la page modifierDonner.html
        return false; 
    } else {
        alert("Mot de passe incorrect !");
        return false; 
    }
}

