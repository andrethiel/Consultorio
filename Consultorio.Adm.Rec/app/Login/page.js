"use client";
import React, { useEffect, useState } from "react";
import Input from "../Components/Input";
import Link from "next/link";
import Button from "../Components/Button";
import axios from "axios";
import Alerta from "../Components/Alerta/index1";

export default function Login() {
  useEffect(() => {
    teste();
  }, []);

  async function teste() {
    const response = await axios
      .post("https://localhost:44357/api/Paciente/Inserir", {
        nomePaciente: "string",
        dataNacimento: "2024-01-21",
        sexo: "s",
        cpf: "11111111111",
        nomeMae: "string",
        endereco: "string",
        telefone: "string",
      })
      .catch(function (error) {
        setErros([]);
        settypeAlert("error");
        if (typeof error.response.data.errors == "undefined") {
          Object.keys(error.response.data).map((item) => {
            if (error.response.data[item] != false) {
              setErros((result) => [...result, error.response.data[item]]);
            }
          });
        } else {
          Object.keys(error.response.data.errors).map((item) =>
            setErros((result) => [
              ...result,
              error.response.data.errors[item][0],
            ])
          );
        }
      });
  }

  const [errors, setErros] = useState([]);
  const [typeAlert, settypeAlert] = useState(null);

  return (
    <div className="md:w-8/12 lg:ml-20 lg:w-4/12">
      <div className="flex items-center h-24">
        <div className="flex-1 text-center px-4 py-2 m-2">
          <p className="text-3xl text-white">Portal Recepção</p>
        </div>
      </div>
      {errors && errors.map((item) => <Alerta type={typeAlert}>{item}</Alerta>)}
      <div className="flex flex-col gap-10">
        <div className="flex">
          <Input placeholder={"Usuario"} />
        </div>
        <div className="flex">
          <Input placeholder={"Senha"} type={"password"} />
        </div>
        <div className="flex justify-between items-center">
          <div className="flex items-center h-5">
            <input type="checkbox" className="w-4 h-4 border" />
            <label className="ml-2 text-md font-medium text-white">
              Lembrar Senha
            </label>
          </div>

          <Link href={"/Adm/Login/Recupera"} className="text-white">
            Esqueceu a senha?
          </Link>
        </div>
        <Button className="bg-white font-medium rounded-lg text-md w-full sm:w-auto px-5 py-2.5 text-center">
          Entrar
        </Button>
      </div>
    </div>
  );
}
