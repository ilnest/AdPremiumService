'use strict';

const modal = document.querySelector('.modal');
const overlay = document.querySelector('.overlay');
const btnCloseModal = document.querySelector('.btn--close-modal');
const adsContainer = document.querySelector('.adsPremium');
const newAdPremium = document.querySelector('.btn-add-new');

const inputLocation = document.querySelector('.modal_form--input--location');
const inputSubcategory = document.querySelector('.modal_form--input--subcategory');
const inputPremiumStart = document.querySelector('.modal_form--input--premium--start');
const inputPremiumEnd = document.querySelector('.modal_form--input--premium--end');


// Modal window
const openModal = function (e) {
    e.preventDefault();
    modal.classList.remove('hidden');
    overlay.classList.remove('hidden');
  };
  
  const closeModal = function () {
    inputLocation.value = '';
    inputSubcategory.value = '';
    inputPremiumStart.value = '';
    inputPremiumEnd.value = '';
    modal.classList.add('hidden');
    overlay.classList.add('hidden');
  };

// Add listeners
newAdPremium.addEventListener('click', openModal);
modal.addEventListener('submit', sendNewAdPremium);
btnCloseModal.addEventListener('click', closeModal);
overlay.addEventListener('click', closeModal);

// Functions
function loadAdPremium()
{
    fetch("https://localhost:44386/api/v1/AdPremium/get").then(resp => 
    {
        return resp.json();
    }).then(data => {
        Array(...data).forEach(x=>renderAdPremium(x));
    }).catch(err => console.log(err.message));          
}



function sendNewAdPremium(e)
{
    const validInputs = (...inputs) =>
      inputs.every(inp => Number.isFinite(inp));
    const allPositive = (...inputs) => inputs.every(inp => inp > 0);

    e.preventDefault();

    // Get data from form
    const location = inputLocation.value;
    const subcategory = inputSubcategory.value;
    const premiumStart= inputPremiumStart.value;
    const premiumEnd= inputPremiumEnd.value;
    fetch("https://localhost:44386/api/v1/AdPremium/add",{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
          },
          redirect: 'follow', // manual, *follow, error
          referrerPolicy: 'no-referrer', // no-referrer, *client
          body: `{
            "locationId": ${location},
            "subcategoryId":  ${subcategory},
            "premiumStart":  "${premiumStart}",
            "premiumEnd":  "${premiumEnd}"
          }`}).then(response=>{
            return response.json();
          }).
          then(data=>{
            renderAdPremium(data)
          }).catch(err=>console.log(err.message));
    closeModal();
        }


function renderAdPremium(adPremium) {
    let html = `
      <li class="adPremium" data-id="${adPremium.adId}">
        <h2 class="adPremium__title">AdPremium</h2>
        <div class="adPremium__details">
          <span class="adPremium__location">🗻${adPremium.location.name}</span>
          <span class="adPremium__subcategory">📃${adPremium.subcategory.name}</span>
        </div>
        <div class="adPremium__details">
          <span class="adPremium__start">${new Intl.DateTimeFormat(navigator.language).format(Date.parse(adPremium.premiumStart))}</span>
        </div>
        <div class="adPremium__details">
        <span class="adPremium__end">${new Intl.DateTimeFormat(navigator.language).format(Date.parse(adPremium.premiumEnd))}</span>
        </div>
    `;
    adsContainer.insertAdjacentHTML('beforebegin', html);
}


// APP

loadAdPremium();
