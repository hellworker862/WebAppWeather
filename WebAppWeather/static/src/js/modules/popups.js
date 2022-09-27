const popupLinks = document.querySelectorAll('.popup-link');
const body = document.querySelector('body');
const main = document.querySelector('main');
const footer = document.querySelector('footer');
const lockPadding = document.querySelectorAll(".lock-padding");

let unlock = true;

const timeout = 800;

if(popupLinks.length > 0) {
    for(let index = 0; index < popupLinks.length; index++) {
        const popupLink = popupLinks[index];
        popupLink.addEventListener("click", function (e) {
            const popupName = popupLink.getAttribute('href').replace('#','');
            const curentPopup = document.getElementById(popupName);
            curentPopup.addEventListener("click", function (e) {
                if(!e.target.closest('.popup-content')) {
                    popupClose(e.target.closest('.popup'));
                }
            });
            popupOpen(curentPopup);
            e.preventDefault();
        });
    }
}

const popupCloseIcon = document.querySelectorAll('.close-popup');
if(popupCloseIcon.length > 0) {
    for(let index = 0; index < popupCloseIcon.length; index++){
        const el = popupCloseIcon[index];
        el.addEventListener('click', function(e) {
            popupClose(el.closest('.popup'));
            e.preventDefault();
        });
    }
}

function popupOpen(curentPopup) {
    if(curentPopup && unlock) {
        const popupActive = document.querySelector('.popup.open-popup');
        if(popupActive){
            popupClose(popupActive, false);
        } else {
            bodyLock();
        }
        curentPopup.classList.add('open-popup');
    }
}

function popupClose(popupActive, doUnlock = true) {
    if(unlock) {
        popupActive.classList.remove('open-popup');
        if(doUnlock){
            bodyUnLock();
        }
    }
}

function bodyLock() {
    const lockPaddingValue = window.innerWidth - document.querySelector('.wrapper').offsetWidth + 'px';
    for(let index = 0; index < lockPadding.length; index++){
        const el =  lockPadding[index];
        el.style.paddingRight = lockPaddingValue;
    }
    main.style.paddingRight = lockPaddingValue;
    footer.style.paddingRight = lockPaddingValue;
    body.classList.add('lock');

    unlock = false;
    setTimeout(function() {
        unlock = true;
    }, timeout);
}

function bodyUnLock() {
    setTimeout( function () {
        for (let index = 0; index < lockPadding.length; index++){
            const el = lockPadding[index];
            el.style.paddingRight = '0px';
        }
        main.style.paddingRight = '0px';
        footer.style.paddingRight = '0px';
        body.classList.remove('lock');
    }, timeout);

    unlock = false;
    setTimeout(function () {
        unlock = true;
    }, timeout);
}

document.addEventListener('keydown', function(e) {
    if(e.which === 27){
        const popupActive = document.querySelector('.popup.open-popup');
        popupClose(popupActive);
    }
});