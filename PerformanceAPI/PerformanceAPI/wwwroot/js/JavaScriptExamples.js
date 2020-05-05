// to grab an element through css things document.querySelector('#option-list li:nth-child(2) .name')
// this only returns the first element that it finds that meets the criteria
//querySelectorAll('') this will return all of the elements that meet the criteria
// if there is only one it will still return it in the collection form

//Array.from() will turn whatever var you pass in into an array

//access an elements text with .textContent or .innerHtml

var pRating = document.getElementsByClassName('p-rating-option');
Array.from(pRating).forEach(function (option) {
	option.addEventListener('click', function () {
		var payIncrease = document.getElementsByClassName('pay-increase-option');
		for (i = 4; i < payIncrease.length; i++) {

		}
	})
})
