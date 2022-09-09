﻿// Copyright(c) 2020 Bitcoin Association.
// Distributed under the Open BSV software license, see the accompanying file LICENSE

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MerchantAPI.APIGateway.Domain.Models;
using MerchantAPI.APIGateway.Domain.Models.APIStatus;
using MerchantAPI.Common.Authentication;

namespace MerchantAPI.APIGateway.Domain.Actions
{
  public interface IMapi : IFaultMapi
  {
    Task<SubmitTransactionResponse> SubmitTransactionAsync(SubmitTransaction request, UserAndIssuer user);
    Task<SubmitTransactionsResponse> SubmitTransactionsAsync(IEnumerable<SubmitTransaction> request, UserAndIssuer user);
    Task<QueryTransactionStatusResponse> QueryTransactionAsync(string id);
    Task<(bool success, List<long> txsWithMissingInputs)> ResubmitMissingTransactionsAsync(string[] mempoolTxs, DateTime? resubmittedAt, int batchSize = 1000);
    SubmitTxStatus GetSubmitTxStatus();
  }
}
