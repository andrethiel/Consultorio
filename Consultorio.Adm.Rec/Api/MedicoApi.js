import { Get } from "./Api";

export async function ListarMedico() {
  const response = await Get("/Medico/Listar", null);

  return response;
}
