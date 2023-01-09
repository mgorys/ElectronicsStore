const url = 'https://localhost:7202/api/';

export async function get(endpoint, paramsObj, query) {
  let wholeUrl = url + endpoint;
  if (paramsObj !== undefined && paramsObj !== null) {
    wholeUrl += '/' + paramsObj;
  }
  wholeUrl += '?';
  if (query !== undefined) {
    if (query.search !== null && query.search !== undefined) {
      wholeUrl += 'search=' + query.search + '&';
    }
    if (query.sortDirection !== null && query.sortDirection !== undefined) {
      wholeUrl += 'sortDirection=' + query.sortDirection + '&';
    }
    if (query.pageSize !== null && query.pageSize !== undefined) {
      wholeUrl += 'pageSize=' + query.pageSize + '&';
    }
    if (query.status !== null && query.status !== undefined)
      wholeUrl += 'status=' + query.status + '&';
    if (query.page !== null && query.page !== undefined)
      wholeUrl += 'page=' + query.page + '&';
  }
  let response = await fetch(wholeUrl, {
    headers: { 'content-type': 'application/json' },
    method: 'GET',
    credentials: 'same-origin',
  });
  if (!response.ok) {
    return response;
  }
  let result = await response.json();
  return result;
}
export async function getAuth(endpoint, paramsObj, query, token) {
  let wholeUrl = url + endpoint;
  if (paramsObj !== undefined && paramsObj !== null) {
    wholeUrl += '/' + paramsObj;
  }
  wholeUrl += '?';
  if (query !== undefined && query !== null) {
    if (query.search !== null && query.search !== undefined)
      wholeUrl += 'search=' + query.search + '&';
    if (query.status !== null && query.status !== undefined)
      wholeUrl += 'status=' + query.status + '&';
    if (query.page !== null && query.page !== undefined)
      wholeUrl += 'page=' + query.page + '&';
    if (query.pageSize !== null && query.pageSize !== undefined) {
      wholeUrl += 'pageSize=' + query.pageSize + '&';
    }
  }
  let response = await fetch(wholeUrl, {
    headers: {
      Authorization: `Bearer ${token}`,
      'content-type': 'application/json',
    },
    method: 'GET',
    credentials: 'same-origin',
  });
  if (!response.ok) {
    return response;
  }

  let result = await response.json();
  return result;
}
export async function getAdmin(endpoint, paramsObj, query, token) {
  let wholeUrl = url + endpoint;
  if (paramsObj !== undefined && paramsObj !== null) {
    wholeUrl += '/' + paramsObj;
  }
  wholeUrl += '?';
  if (query !== undefined) {
    if (query.search !== null && query.search !== undefined)
      wholeUrl += 'search=' + query.search + '&';
    if (query.status !== null && query.status !== undefined)
      wholeUrl += 'status=' + query.status + '&';
    if (query.page !== null && query.page !== undefined)
      wholeUrl += 'page=' + query.page + '&';
    if (query.pageSize !== null && query.pageSize !== undefined) {
      wholeUrl += 'pageSize=' + query.pageSize + '&';
    }
  }

  let response = await fetch(wholeUrl, {
    headers: {
      Authorization: `Bearer ${token}`,
      'content-type': 'application/json',
    },
    method: 'GET',
    credentials: 'same-origin',
  });
  if (!response.ok) {
    return response;
  }

  let result = await response.json();
  return result;
}
export async function postAdmin(endpoint, paramsObj, token, body) {
  let wholeUrl;
  if (paramsObj !== undefined) {
    wholeUrl = url + endpoint + '/' + paramsObj;
  } else {
    wholeUrl = url + endpoint;
  }
  let response = await fetch(wholeUrl, {
    body: JSON.stringify(body),
    headers: {
      Authorization: `Bearer ${token}`,
      'content-type': 'application/json',
    },
    method: 'POST',
    credentials: 'same-origin',
  });
  if (!response.ok) {
    throw new Error(response.statusText);
  }

  let result = await response.json();
  return result;
}
export async function deleteAdmin(endpoint, paramsObj, token) {
  let wholeUrl;
  if (paramsObj !== undefined) {
    wholeUrl = url + endpoint + '/' + paramsObj;
  } else {
    return false;
  }
  let response = await fetch(wholeUrl, {
    headers: {
      Authorization: `Bearer ${token}`,
      'content-type': 'application/json',
    },
    method: 'DELETE',
    credentials: 'same-origin',
  });
  if (!response.ok) {
    throw new Error(response.statusText);
  }
  let result = await response.json();
  return result;
}
export async function loginUser(email, password) {
  let data = { email, password };
  let wholeUrl = url + 'account/login';
  let response = await fetch(wholeUrl, {
    body: JSON.stringify(data),
    credentials: 'same-origin',
    headers: {
      'content-type': 'application/json',
    },
    method: 'POST',
  });

  if (!response.ok) {
    return response;
  }
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
    return response;
  }
  return response;
}
export async function postPurchase(cart, token, email) {
  let purchaseList = new Array();
  cart.forEach((element) => {
    purchaseList.push({ name: element.name, count: element.quantity });
  });
  const dataHelper = {
    PurchaseList: purchaseList,
    Email: email,
  };
  let wholeUrl = url + 'purchase';
  let response = await fetch(wholeUrl, {
    body: JSON.stringify(dataHelper),
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
