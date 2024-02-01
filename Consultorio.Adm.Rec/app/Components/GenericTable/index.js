import React from "react";
import Button from "../Button";
import { useRouter } from "next/navigation";

function GenericTable({ titulo, colunas, objetos, acao }) {
  const route = useRouter();
  const Row = ({ data }) => {
    const keys = Object.keys(data);

    function linhas(key) {
      for (var item of objetos) {
        if (item == key) {
          return (
            <td
              className="px-4 py-2 text-center"
              onClick={() =>
                item == "nomePaciente"
                  ? route.push(`/Adm/Consulta?paciente=${data.guid}`)
                  : null
              }
            >
              {data[key]}
            </td>
          );
        }
      }
    }

    return (
      <tr>
        {keys.map((key) => linhas(key))}
        {typeof acao != "undefined" ? (
          <td className="px-4 py-2 text-center">
            <Button
              onClick={() =>
                route.push(`/Adm/Pacientes/Cadastrar?paciente=${data.guid}`)
              }
            >
              Editar
            </Button>
          </td>
        ) : null}
      </tr>
    );
  };

  return (
    <table className="table-auto w-full">
      <thead>
        <tr>
          {titulo.map((item, index) => (
            <th className="px-4 py-2" key={index}>
              {item}
            </th>
          ))}
          {typeof acao != "undefined" ? (
            <th className="px-4 py-2">Ação</th>
          ) : null}
        </tr>
      </thead>
      <tbody>
        {colunas.map((item) => (
          <Row data={item} />
        ))}
      </tbody>
    </table>
  );
}

export default GenericTable;
