document.addEventListener('DOMContentLoaded', function () {
    const track = document.querySelector('.track');
    const slides = Array.from(track.querySelectorAll('.slide'));
    const nextButton = document.querySelector('.carouselbtn.right');
    const prevButton = document.querySelector('.carouselbtn.left');

    slides.forEach(function (slide, index) {
        slide.style.left = slides[0].offsetWidth * index + 'px';
    });

    function moveToSlide(currentSlide, targetSlide) {
        const newPosition = -targetSlide.offsetLeft;
        track.style.transform = 'translateX(' + newPosition + 'px)';
        currentSlide.classList.remove('current');
        targetSlide.classList.add('current');
    }

    function updateUI(targetIndex) {
        prevButton.classList.toggle('hide', targetIndex === 0);
        nextButton.classList.toggle('hide', targetIndex === slides.length - 1);
    }

    prevButton.addEventListener('click', function () {
        const currentSlide = track.querySelector('.current');
        const prevSlide = currentSlide.previousElementSibling || slides[slides.length - 1];
        moveToSlide(currentSlide, prevSlide);
        updateUI(slides.indexOf(prevSlide));
    });

    nextButton.addEventListener('click', function () {
        const currentSlide = track.querySelector('.current');
        const nextSlide = currentSlide.nextElementSibling || slides[0];
        moveToSlide(currentSlide, nextSlide);
        updateUI(slides.indexOf(nextSlide));
    });
});

function redirectToStationeryDetails(element) {
    var stationeryID = element.getAttribute('stationeryID');
    window.location.href = 'StationeryDetails.aspx?stationeryID=' + stationeryID;
}
