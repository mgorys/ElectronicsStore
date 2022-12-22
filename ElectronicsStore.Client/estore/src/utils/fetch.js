const url = 'https://localhost:7202/api/';
export async function get(endpoint, paramsObj, page) {
  let wholeUrl;
  if (paramsObj !== '' && page !== undefined) {
    wholeUrl = url + endpoint + '/' + paramsObj + '?page=' + page;
  } else if (paramsObj !== '' && page === undefined) {
    wholeUrl = url + endpoint + '/' + paramsObj;
  } else {
    wholeUrl = url + endpoint;
  }
  let response = await fetch(wholeUrl, {
    headers: { 'content-type': 'application/json' },
    method: 'GET',
    credentials: 'same-origin',
  });
  if (!response.ok) {
    console.log('error z url : ', wholeUrl);
    throw new Error(response.statusText);
  }

  let result = await response.json();
  console.log('poszlo z url', wholeUrl, result);
  return result;
}

export async function loginUser(email, password) {
  let data = { email, password };
  let wholeUrl = url + 'account/login';
  console.log(wholeUrl);
  let response = await fetch(wholeUrl, {
    body: JSON.stringify(data),
    credentials: 'same-origin',
    headers: {
      'content-type': 'application/json',
    },
    method: 'POST',
  });

  if (!response.ok) {
    throw new Error(response.statusText);
  }
  console.log(response);
  return await response.json();
}

export async function registerUser(email, password, confirmPassword, name) {
  let data = { name, email, password, confirmPassword };
  let wholeUrl = url + 'account/register';
  let response = await fetch(wholeUrl, {
    body: JSON.stringify(data),
    credentials: 'same-origin',
    headers: {
      'content-type': 'application/json',
    },
    method: 'POST',
  });

  if (!response.ok) {
    throw new Error(response.statusText);
  }
  console.log(response);
  return await response;
}

export async function postPurchase(cart, token) {
  let data = [];
  cart.forEach((element) => {
    data.push({ name: element.name, count: element.quantity });
  });
  let wholeUrl = url + 'purchase';
  let response = await fetch(wholeUrl, {
    body: JSON.stringify(data),
    credentials: 'same-origin',
    headers: {
      Authorization: `Bearer ${token}`,
      'content-type': 'application/json',
    },
    method: 'POST',
  });
  if (!response.ok) {
    throw new Error(response.statusText);
  }
  return await response.json();
}
