"use client";
import React, { useEffect } from "react";
import Button from "../Button";

function GenericTable({ titulo, colunas, acao }) {
  const Row = ({ data }) => {
    const keys = Object.keys(data);
    return (
      <tr>
        {keys.map((key) =>
          key.toLowerCase() != "id" ? (
            <td className="px-4 py-2 text-center">{data[key]}</td>
          ) : null
        )}
        {typeof acao != "undefined" ? (
          <td className="px-4 py-2 text-center">
            <Button onClick={() => console.log(data.Id)}>Editar</Button>
          </td>
        ) : null}
      </tr>
    );
  };

  return (
    <table className="table-auto w-screen">
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
