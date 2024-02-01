let resposta = [];

export default function ErrorAxios(error) {
  if (typeof error.response.data.errors == "undefined") {
    Object.keys(error.response.data).map((item) => {
      if (error.response.data[item] != false) {
        resposta.push(error.response.data[item]);
      }
    });
    return resposta;
  } else {
    Object.keys(error.response.data.errors).map((item) =>
      resposta.push(error.response.data.errors[item][0])
    );
  }
  return resposta;
}
