import axios from "axios";

const URLBASE = process.env.NEXT_PUBLIC_API_URL;

export async function Post(url, data, token) {
  const UrlCompleto = URLBASE.concat(url);
  const response = await axios.post(UrlCompleto, data);

  return response;
}

export async function Get(url, token) {
  const UrlCompleto = URLBASE.concat(url);
  const response = await axios.get(UrlCompleto);

  return response;
}
