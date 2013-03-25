package es.uniovi.asw.entrecine;

public class Sesion {

	private TipoSesion tipo;
	private boolean[][] butacas;
	

	public Sesion(TipoSesion tipo,int filas,int columnas) {
		super();
		this.tipo = tipo;
		
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

}
