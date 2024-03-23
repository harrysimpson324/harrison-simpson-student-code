// add pageTitle
const pageTitle = 'My Shopping List';
// add groceries
const groceries = ['cheese', 'lettuce', 'your mom', 'iron supplements', 'some more cheese', 
'yogurt', '2% milk', 'a pool cue', 'thirty thirsty lions', 'seventeen gay pirates'];

const groceriesUlElement = document.getElementById('groceries');

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  const titleElement = document.getElementById('title');
  titleElement.innerText = pageTitle;

}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {

  for (let i = 0; i < groceries.length; i++) {
    const newListItem = document.createElement('li');
    newListItem.innerText = groceries[i];
    groceriesUlElement.insertAdjacentElement('beforeend', newListItem);
  }

}

/**
 * This function will be called when the button is clicked. You will need to get a reference
 * to every list item and add the class completed to each one
 */
function markCompleted() {

  const listItems = groceriesUlElement.children;

  for (let i = 0; i < listItems.length; i++) {
    listItems[i].classList.add('completed');
  }

}

setPageTitle();

displayGroceries();

// Don't worry too much about what is going on here, we will cover this when we discuss events.
document.addEventListener('DOMContentLoaded', () => {
  // When the DOM Content has loaded attach a click listener to the button
  const button = document.querySelector('.btn');
  button.addEventListener('click', markCompleted);
});
