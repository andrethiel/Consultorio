import { Get } from "./Api";

export function NumeroAtendimento() {
  const response = Get("/Sequence/Atendimento", null);

  return response;
}
