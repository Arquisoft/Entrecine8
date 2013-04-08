package es.uniovi.asw.entrecine;

public class Reserva {

	private Sesion sesion;
	// [numeroEntrada]
	private int[][] reservas;
	private static int FILA = 0;
	private static int COLUMNA = 1;

	public Reserva(Sesion sesion, int[][] reservas) {
		this.sesion = sesion;
		this.reservas = reservas;
	}

	public boolean reservar() {
		for (int i = 0; i < reservas.length; i++)
			if (!sesion.reservar(reservas[i][FILA], reservas[i][COLUMNA]))
				return false;
		return true;

	}

	public double getPrecio() {
		return sesion.getPrecio() * reservas.length;
	}
}
