package es.uniovi.asw.entrecine;

import java.util.Date;

public class Sesion {

	private TipoSesion tipo;
	private boolean[][] butacas;
	private Date fecha;
	private String tituloPelicula;

	public Sesion(TipoSesion tipo, int filas, int columnas, Date date,
			String tituloPelicula) {
		super();
		this.tipo = tipo;
		butacas = new boolean[filas][columnas];
		this.fecha = date;
		this.tituloPelicula = tituloPelicula;
	}

	public boolean reservar(int fila, int columna) {
		if (butacas[fila][columna])
			return false;
		else
			butacas[fila][columna] = true;
		return true;
	}

	public double getPrecio() {
		return tipo.getPrecio();
	}

	public Date getFecha() {
		return fecha;
	}

	public String getTituloPelicula() {
		return tituloPelicula;
	}

}
