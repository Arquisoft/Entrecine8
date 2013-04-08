package es.uniovi.asw.entrecine.persistencia;


import java.sql.CallableStatement;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;

public class AccesoABases {
	private static java.sql.Connection conn;

	public static void main(String[] args) throws ClassNotFoundException,
			SQLException {
		establecerConexion();
		reservar(1,87,3);
	}

	public static boolean reservar(Integer idsesion, int fila, int columna) {
		try {
			CallableStatement cs=conn.prepareCall("{? = call ENTRECINE_CHECKRESERVATION(?,?,?)}");
			cs.registerOutParameter(1,java.sql.Types.INTEGER);
			cs.setInt(2, idsesion);
			cs.setInt(3, columna);
			cs.setInt(4, fila);
			cs.executeQuery();
			return cs.getInt(1)==0;
		} catch (SQLException e) {
			e.printStackTrace();
			return false;
		}
		
	}

	public static void establecerConexion() throws ClassNotFoundException,
			SQLException {
		Class.forName("oracle.jdbc.driver.OracleDriver");
		String url = "jdbc:oracle:thin:@156.35.94.99:1521:DESA";
		String username = "UO218193";
		String password = "youshallnotpass";
		conn = DriverManager.getConnection(url, username, password);
	}

	public static void sacarCoches(boolean mostrar) throws SQLException {
		java.sql.Statement stat = conn.createStatement();
		ResultSet rs = stat.executeQuery("select nombrech from coches ");
		while (rs.next()) {
			String nombre = rs.getString(1);
			if (mostrar)
				System.out.println(nombre);
		}
		rs.close();
	}

	public static void comparar() throws SQLException {
		String cadena = "";
		int i;
		java.sql.Statement stat = conn.createStatement();
		double t1 = System.currentTimeMillis(), t2;
		for (i = 0; i < 1000; i++) {
			ResultSet rs = stat
					.executeQuery("select nombrech from coches where nombrech='ibiza'");
			while (rs.next()) {
				cadena = rs.getString(1);
			}
		}
		t2 = System.currentTimeMillis();
		System.out.println(i + "Iteraciones con " + (t2 - t1)
				+ "ms para Statement.");
		java.sql.PreparedStatement prepared = conn
				.prepareStatement("select nombrech from coches where nombrech=?");
		t1 = System.currentTimeMillis();
		for (i = 0; i < 1000; i++) {
			prepared.setString(1, "ibiza");
			ResultSet rs = prepared.executeQuery();
			while (rs.next()) {
				cadena = rs.getString(1);
			}
		}
		t2 = System.currentTimeMillis();
		System.out.println(i + "Iteraciones con " + (t2 - t1)
				+ "ms para PreparedStatement.");
		System.out.println(cadena.substring(cadena.length()));
	}

	public static void costesConexiones() throws ClassNotFoundException,
			SQLException {
		conn.close();
		int i;
		double t1 = System.currentTimeMillis(), t2;
		for (i = 0; i < 1000; i++) {
			establecerConexion();
			sacarCoches(false);
			conn.close();
		}
		t2 = System.currentTimeMillis();
		System.out.println(i + "Iteraciones con " + (t2 - t1)
				+ "ms al crear las conexiones dentro del bucle.");

		establecerConexion();
		t1 = System.currentTimeMillis();
		for (i = 0; i < 1000; i++)
			sacarCoches(false);
		t2 = System.currentTimeMillis();

		conn.close();
		System.out.println(i + "Iteraciones con " + (t2 - t1)
				+ "ms al crear las conexiones dentro del bucle.");

	}
}
