Feature: Reservation

  Scenario: Reserve a seat
    Given a reservation of 2 seats with price 4 euros
    When I ask the total price
    Then the result should be 8