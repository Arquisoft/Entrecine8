package es.uniovi.asw.entrecine;

import static org.fest.assertions.Assertions.assertThat;
import cucumber.api.Format;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import cucumber.runtime.PendingException;
import es.uniovi.asw.entrecine.Reservation;

public class ReservationSteps {
	
	private Reservation r;
	
@Given("^a reservation of (\\d+) seats with price (\\d+) euros$")
public void a_reservation_of_seats_with_price_euros(int seats, double price) throws Throwable {
    r = new Reservation(seats,price);
}

@When("^I ask the total price$")
public void I_ask_the_total_price() throws Throwable {
}

@Then("^the result should be (\\d+)$")
public void the_result_should_be(int total) throws Throwable {
	assertThat(r.getPrice()).isEqualTo(total);
}

}