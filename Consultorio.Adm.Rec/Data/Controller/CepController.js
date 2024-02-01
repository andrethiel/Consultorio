import axios from "axios";

export async function BuscaCep(cep) {
  const response = await axios.get(
    `https://opencep.com/v1/${cep.replace("-", "")}`
  );
  return response.data;
}
