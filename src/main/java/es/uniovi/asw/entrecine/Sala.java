package es.uniovi.asw.entrecine;

import java.util.Date;
import java.util.Map;

public class Sala {

	private Map<Date, Sesion> sesiones;

	
	public Sala() {
	}


	public boolean reservar(Date date, int fila, int columna) {
		return sesiones.get(date).reservar(fila, columna);
	}
}
