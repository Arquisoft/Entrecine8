package es.uniovi.asw.entrecine;

import java.util.Date;

import es.uniovi.asw.entrecine.persistencia.AccesoABases;

public class Sesion {

	private TipoSesion tipo;
	private Date fecha;
	private String tituloPelicula;
	private Integer id;

	public Sesion(Integer id, TipoSesion tipo, Date date, String tituloPelicula) {
		this.tipo = tipo;
		this.fecha = date;
		this.tituloPelicula = tituloPelicula;
		this.id=id;
	}

	public boolean reservar(int fila, int columna) {
		return AccesoABases.reservar(id, fila, columna);
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
