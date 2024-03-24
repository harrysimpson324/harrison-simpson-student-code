let allItemsIncomplete = true;
const pageTitle = 'My Shopping List';
const groceries = [
  { id: 1, name: 'Oatmeal', completed: false },
  { id: 2, name: 'Milk', completed: false },
  { id: 3, name: 'Banana', completed: false },
  { id: 4, name: 'Strawberries', completed: false },
  { id: 5, name: 'Lunch Meat', completed: false },
  { id: 6, name: 'Bread', completed: false },
  { id: 7, name: 'Grapes', completed: false },
  { id: 8, name: 'Steak', completed: false },
  { id: 9, name: 'Salad', completed: false },
  { id: 10, name: 'Tea', completed: false }
];

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  const title = document.getElementById('title');
  title.innerText = pageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  const ul = document.querySelector('ul');
  groceries.forEach((item) => {
    const li = document.createElement('li');
    li.innerText = item.name;
    const checkCircle = document.createElement('i');
    checkCircle.setAttribute('class', 'far fa-check-circle');
    li.appendChild(checkCircle);
    ul.appendChild(li);
  });
}

function addLiDoubleClickListeners() {
  const lis = document.querySelectorAll('li');

  console.log('inside adding double click listeners');

  lis.forEach( (element) => {

    console.log('inside forEach loop');

    element.addEventListener('dblclick', (event) => {

      console.log('inside anon funct to perform doubleclick logic');

      if (element.classList.contains('completed')) {

        console.log('inside dblclick conditional');

        element.classList.remove('completed');
        const icon = element.firstElementChild;
        icon.classList.remove('completed');

      }
    });
  });
}

function addLiClickListeners() {

  const lis = document.querySelectorAll('li');

  lis.forEach((element) => {

    element.addEventListener('click', () => {

      if (!element.classList.contains('completed')) {
        element.classList.add('completed');
        const icon = element.firstElementChild;
        icon.classList.add('completed');
      }
    });

  });
}

function addMarkAllButtonListener() {

  const markAllButton = document.getElementById('toggleAll');

  markAllButton.addEventListener('click', () => {

    if (allItemsIncomplete) {
      markAllComplete();
      markAllButton.innerText = 'Mark All Incomplete';
    }

    else {
      markAllIncomplete();
      markAllButton.innerText = 'Mark All Complete';

    }

  });


}

function markAllComplete() {

  const lis = document.body.querySelectorAll('li');
  lis.forEach((li) => {
    if (!li.classList.contains('completed')) {
     li.classList.add('completed');
     li.firstElementChild.classList.add('completed');
    }
  });
  allItemsIncomplete = false;
}

function markAllIncomplete() {

  const lis = document.body.querySelectorAll('li');
  lis.forEach((li) => {
    if (li.classList.contains('completed')) {
     li.classList.remove('completed');
     li.firstElementChild.classList.remove('completed');
    }
  });
  allItemsIncomplete = true;
}

document.addEventListener('DOMContentLoaded', () => {

  setPageTitle();
  displayGroceries();

  addLiClickListeners();
  addLiDoubleClickListeners();

  addMarkAllButtonListener();

});
