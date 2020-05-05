var ratingList = document.getElementsByClassName('rating-option');
var ratingSelect = document.getElementById('projected-rating')
var payOption1 = document.getElementById('pay-option-1');
var payOption2 = document.getElementById('pay-option-2');
var payOption3 = document.getElementById('pay-option-3');
console.log(ratingList);
console.log(ratingSelect);


ratingSelect.addEventListener('click', function () {
	var selectedRating = ratingSelect.options[ratingSelect.selectedIndex].value;
	console.log('Second Funciton is working')
	console.log(selectedRating);

	if (selectedRating === 'EC') {
		payOption1.setAttribute('value', 4.5)
		payOption2.setAttribute('value', 5.0)
		payOption3.setAttribute('value', 5.5)

		payOption1.textContent = '4.5%'
		payOption2.textContent = '5%'
		payOption3.textContent = '5.5%'
	}
	if (selectedRating === 'NI') {
		payOption1.setAttribute('value', 0)
		payOption2.setAttribute('value', 0)
		payOption3.setAttribute('value', 0)

		payOption1.textContent = '0%'
		payOption2.textContent = '0%'
		payOption3.textContent = '0%'
	}
	if (selectedRating === 'OP') {
		payOption1.setAttribute('value', 3.25)
		payOption2.setAttribute('value', 3.5)
		payOption3.setAttribute('value', 3.75)

		payOption1.textContent = '3.25%'
		payOption2.textContent = '3.5%'
		payOption3.textContent = '3.75%'
	}
	if (selectedRating === 'SC') {
		payOption1.setAttribute('value', 2.25)
		payOption2.setAttribute('value', 2.5)
		payOption3.setAttribute('value', 2.75)

		payOption1.textContent = '2.25%'
		payOption2.textContent = '2.5%'
		payOption3.textContent = '2.75%'
	}
	if (selectedRating === 'SC+') {
		payOption1.setAttribute('value', 2.75)
		payOption2.setAttribute('value', 3.0)
		payOption3.setAttribute('value', 3.25)

		payOption1.textContent = '2.75%'
		payOption2.textContent = '3%'
		payOption3.textContent = '3.25%'
	}
	if (selectedRating === 'SC-') {
		payOption1.setAttribute('value', 0)
		payOption2.setAttribute('value', 0)
		payOption3.setAttribute('value', 0)

		payOption1.textContent = '0%'
		payOption2.textContent = '0%'
		payOption3.textContent = '0%'
	}
	if (selectedRating === 'SP') {
		payOption1.setAttribute('value', 2.0)
		payOption2.setAttribute('value', 2.1)
		payOption3.setAttribute('value', 2.25)

		payOption1.textContent = '2%'
		payOption2.textContent = '2.1%'
		payOption3.textContent = '2.25%'
	}
	if (selectedRating === 'UP') {
		payOption1.setAttribute('value', 0)
		payOption2.setAttribute('value', 0)
		payOption3.setAttribute('value', 0)

		payOption1.textContent = '0%'
		payOption2.textContent = '0%'
		payOption3.textContent = '0%'
	}
});