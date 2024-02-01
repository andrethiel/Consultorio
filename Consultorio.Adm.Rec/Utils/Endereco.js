export function FormatarEndereco(endereco, numero, bairro, municipio, cidade) {
  return `${endereco},${numero},${bairro},${municipio},${cidade}`;
}

export function RetornarEndereco(endereco) {
  return endereco.split(",")[0];
}
export function RetornarNumero(endereco) {
  return endereco.split(",")[1];
}
export function RetornarBairro(endereco) {
  return endereco.split(",")[2];
}
export function RetornarMunicipio(endereco) {
  return endereco.split(",")[3];
}
export function RetornarEstado(endereco) {
  return endereco.split(",")[4];
}
