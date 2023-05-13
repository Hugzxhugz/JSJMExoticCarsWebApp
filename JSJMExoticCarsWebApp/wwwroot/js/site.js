var initialState = localStorage.getItem('asideState') || 'hidden';
var aside = document.querySelector('aside');
var toggleButton = document.querySelector('.toggle-aside');

aside.classList.add(initialState);

toggleButton.addEventListener('click', function () {
    aside.classList.toggle('hidden');

    var currentState = aside.classList.contains('hidden') ? 'hidden' : '';
    localStorage.setItem('asideState', currentState);
});
