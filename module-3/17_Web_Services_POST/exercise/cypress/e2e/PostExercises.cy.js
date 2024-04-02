describe("Web API (POST) Exercises", () => {

  // reset database before each test
  beforeEach(() => {
    cy.readFile('./db/readit-test-start.json', null).then((contents) => {
      cy.writeFile('./db/readit-test.json', contents);
    });
  })

  describe('Part One: CRUD Topics', () => {

    it('Step One Tests: should create new topic', () => {
      cy.visit('/topic/create')
      cy.get('input[name="title"]').type('This is a TEST title for a new topic');
      cy.get('button.btn-submit').click();
      cy.contains('This is a TEST title for a new topic');
      cy.get('div.topic').should('have.length', 21);
    });

    it('Step Two Tests: should update a topic', () => {
      cy.visit('/');
      cy.contains('Introduction to Programming');
      cy.get('div.topic a').first().click();
      cy.get('button.btn-edit').click();
      cy.get('input[name="title"]').clear();
      cy.get('input[name="title"]').type('Updated TEST title');
      cy.get('button.btn-submit').click();
      cy.contains('Updated TEST title');
    });

    it('Step Three Tests: should delete a topic', () => {
      cy.visit('/');
      cy.contains('Introduction to Programming');
      cy.get('div.topic a').first().click();
      cy.get('button.btn-delete').click();
      cy.visit('/');
      cy.get('div.topic').should('have.length', 19);
    });

  });

  describe('Part Two: CRUD Messages', () => {

    it('Step One Tests: should create new message', () => {
      cy.visit('/topic/1/message/create')
      cy.get('input[name="title"]').type('TEST TITLE');
      cy.get('textarea[name="messageText"]').type('TEST MESSAGE TEXT');
      cy.get('button.btn-submit').click();
      cy.contains('TEST TITLE');
      cy.contains('TEST MESSAGE TEXT')
      cy.get('.message').should('have.length', 5);
    });

    it('Step Two Tests: should update a message', () => {
      cy.visit('/topic/1');
      cy.get('.message').first().click();
      cy.get('button.btn-edit').click();
      cy.get('input[name="title"]').clear();
      cy.get('input[name="title"]').type('UPDATED TEST TITLE');
      cy.get('textarea[name="messageText"]').clear();
      cy.get('textarea[name="messageText"]').type('UPDATED TEST MESSAGE TEXT');
      cy.get('button.btn-submit').click();
      cy.contains('UPDATED TEST TITLE');
      cy.contains('UPDATED TEST MESSAGE TEXT')
    });

    it('Step Three Tests: should delete a message', () => {
      cy.visit('/topic/1');
      cy.get('.message').first().click();
      cy.contains('Getting Started in Programming');
      cy.contains('Hi everyone! I\'m new to programming and excited to learn.');
      cy.get('button.btn-delete').click();
      cy.get('.message').should('have.length', 3);
    });

  });

});
