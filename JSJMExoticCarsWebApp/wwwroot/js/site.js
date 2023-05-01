// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var aside = document.querySelector('aside');
var toggleButton = document.querySelector('.toggle-aside');

toggleButton.addEventListener('click', function() {
    aside.classList.toggle('hidden')
});